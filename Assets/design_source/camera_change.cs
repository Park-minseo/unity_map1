using UnityEngine;
using Cinemachine;

public class camera_change : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    void Update()
    {
        // Z 키를 누르면
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (virtualCamera != null)
            {
                // Cinemachine3rdPersonFollow 컴포넌트를 가져옵니다.
                Cinemachine3rdPersonFollow thirdPersonFollow = virtualCamera.GetCinemachineComponent<Cinemachine3rdPersonFollow>();

             
                if (thirdPersonFollow != null)
                {
                    if (thirdPersonFollow.CameraDistance == 4)
                    {
                        thirdPersonFollow.Damping = Vector3.zero;
                        thirdPersonFollow.ShoulderOffset = Vector3.zero;
                        thirdPersonFollow.CameraDistance = -1;
                    }
                    else
                    {
                        thirdPersonFollow.Damping = new Vector3(0.1f, 0.25f, 0.3f);
                        thirdPersonFollow.ShoulderOffset = new Vector3(1f, 0f, 0f);
                        thirdPersonFollow.CameraDistance = 4;
                    }
                   
                }
            }
        }
    }
}
