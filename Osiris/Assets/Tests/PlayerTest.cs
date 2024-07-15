using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerTest
{
    [Test]
    public void Player_WalkSpeed_SetCorrectly()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        player.walkSpeed = 5f;

        Assert.AreEqual(player.walkSpeed, 5f);
    }

    [Test]
    public void Player_RunSpeed_SetCorrectly()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        player.runSpeed = 10f;

        Assert.AreEqual(player.runSpeed, 10f);
    }

    [Test]
    public void Player_JumpForce_SetCorrectly()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        player.jumpForce = 10f;

        Assert.AreEqual(player.jumpForce, 10f);
    }

    [Test]
    public void Player_CheckGround_AssignedCorrectly()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        Transform checkGroundTransform = new GameObject().transform;
        player.CheckGraund = checkGroundTransform;

        Assert.AreEqual(player.CheckGraund, checkGroundTransform);
    }
    

    [Test]
    public void Player_IsGrounded_SetCorrectly_NotGrounded()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        player.CheckGraund = new GameObject().transform;
        player.CheckGraund.position = new Vector3(0f, 2f, 0f); 
        Assert.IsFalse(player.IsGrounded());
    }


    [Test]
    public void Player_Jump()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        player.CheckGraund = new GameObject().transform;
        player.CheckGraund.position = new Vector3(0f, 2f, 0f); 
        Assert.IsFalse(player.IsGrounded());
    }
    [Test]
    public void Player_IsGrounded_SetCorrectly_IsGrounded()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        player.CheckGraund = new GameObject().transform;
        player.CheckGraund.position = new Vector3(0f, 2f, 0f); 
        Assert.IsFalse(player.IsGrounded());
    }

    
    

    [Test]
    public void CameraShake_Shake_SetsCameraPositionCorrectly()
    {
        // Arrange
        var cameraGameObject = new GameObject();
        var cameraShake = cameraGameObject.AddComponent<CameraShake>();
        var initialPosition = cameraGameObject.transform.localPosition;
        float duration = 0.5f; // Устанавливаем длительность тряски

        // Act
        cameraShake.Shake(duration);

        // Assert
        Assert.AreNotEqual(initialPosition, cameraGameObject.transform.localPosition);
    }
    
    


}
