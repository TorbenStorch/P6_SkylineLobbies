/*-------------------------------------------------------
Creator: Code from Alex Zarenko (Group 2) - Implemented/Adjusted by Torben Storch
Expanded Realities P6
last change: 14-07-2022
---------------------------------------------------------*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class ProjectionPlaneCamera : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Projection plane")]
    public ProjectionPlane ProjectionScreen;
    public bool ClampNearPlane = true;
    [Header("Helpers")]
    public bool DrawGizmos = true;

    private Vector3 eyePos;
    //From eye to projection screen corners
    private float n, f;

    Vector3 va, vb, vc, vd;

    //Extents of perpendicular projection
    float l, r, b, t;

    Vector3 viewDir;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();

    }
    private void OnDrawGizmos()
    {
        if (ProjectionScreen == null)
            return;

        if (DrawGizmos)
        {
            var pos = transform.position;
            Gizmos.color = Color.green;
            Gizmos.DrawLine(pos, pos + va);
            Gizmos.DrawLine(pos, pos + vb);
            Gizmos.DrawLine(pos, pos + vc);
            Gizmos.DrawLine(pos, pos + vd);

            Vector3 pa = ProjectionScreen.BottomLeft;
            Vector3 vr = ProjectionScreen.DirRight;
            Vector3 vu = ProjectionScreen.DirUp;

            Gizmos.color = Color.white;
            Gizmos.DrawLine(pos, viewDir);
        }
    }

    private void LateUpdate()
    {
        if (ProjectionScreen != null)
        {
            Vector3 pa = ProjectionScreen.BottomLeft;
            Vector3 pb = ProjectionScreen.BottomRight;
            Vector3 pc = ProjectionScreen.TopLeft;
            Vector3 pd = ProjectionScreen.TopRight;

            Vector3 vr = ProjectionScreen.DirRight;
            Vector3 vu = ProjectionScreen.DirUp;
            Vector3 vn = ProjectionScreen.DirNormal;

            Matrix4x4 M = ProjectionScreen.M;

            eyePos = transform.position;

            //From eye to projection screen corners
            va = pa - eyePos;
            vb = pb - eyePos;
            vc = pc - eyePos;
            vd = pd - eyePos;

            viewDir = eyePos + va + vb + vc + vd;

            //distance from eye to projection screen plane
            float d = -Vector3.Dot(va, vn);
            if (ClampNearPlane)
                cam.nearClipPlane = d;
            n = cam.nearClipPlane;
            f = cam.farClipPlane;

            float nearOverDist = n / d;
            l = Vector3.Dot(vr, va) * nearOverDist;
            r = Vector3.Dot(vr, vb) * nearOverDist;
            b = Vector3.Dot(vu, va) * nearOverDist;
            t = Vector3.Dot(vu, vc) * nearOverDist;
            Matrix4x4 P = Matrix4x4.Frustum(l, r, b, t, n, f);

            //Translation to eye position
            Matrix4x4 T = Matrix4x4.Translate(-eyePos);


            Matrix4x4 R = Matrix4x4.Rotate(Quaternion.Inverse(transform.rotation) * ProjectionScreen.transform.rotation);
            cam.worldToCameraMatrix = M * R * T;

            cam.projectionMatrix = P;
        }
    }
}
