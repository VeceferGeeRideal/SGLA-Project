using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricRenderer : MonoBehaviour
{
    private Animator animator;
    private int lastDirection = 0;
    private Vector2 vecDirection;
    
   
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    public void SetDirection(Vector2 Dir, string Action, float Speed) {
        string STATE = null;
        switch (Action) {
            case "Move":
                if (Dir.magnitude < 0.01f) 
                {
                    STATE = "IDLE";
                }
                else
                {
                    STATE = "RUN";
                    lastDirection = DirectionToIndex(Dir, 8);
                    vecDirection = Dir;
                }
                animator.SetFloat("MovementSpeed", Speed);
                animator.SetFloat("Direction", lastDirection);
                animator.Play(STATE);
            break;
        }
    }

    public static int DirectionToIndex(Vector2 movDir, int sliceCount) {

        float step = 360f / sliceCount;
        float halfstep = step / 2;
        float angle = Vector2.SignedAngle(Vector2.up, movDir) + halfstep;
        if(angle < 0)
        {
            angle += 360;
        }
        float stepCount = angle / step;
        return Mathf.FloorToInt(stepCount);
    }

    public int GetDirection() {
        return lastDirection;
    }

}
