using Unity.Cinemachine;
using UnityEngine;

public class AlignCameraToPlanet : CinemachineExtension
{
    [SerializeField] Transform planet;

    protected override void PostPipelineStageCallback(CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            if (transform != null && planet != null)
            {
                Vector3 planetUp = (transform.position - planet.position).normalized;

                // 현재 카메라의 Forward 방향
                Vector3 cameraForward = state.RawOrientation * Vector3.forward;

                // 새 회전 생성: 주어진 Forward와 Up 방향을 기반으로
                Quaternion newOrientation = Quaternion.LookRotation(cameraForward, planetUp);

                // 회전 적용
                state.RawOrientation = newOrientation;
            }
        }
    }
}
