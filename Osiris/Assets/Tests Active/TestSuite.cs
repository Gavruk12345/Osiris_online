using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class TestSuite
{
    [UnityTest]
    // Test if the player moves correctly when calling MoveCharacter
    public IEnumerator Player_MoveCharacter_CorrectMovement()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        Rigidbody2D rb = playerObject.AddComponent<Rigidbody2D>();

        // Call the MoveCharacter method
        player.MoveCharacter(1f, 5f);

        // Wait for one frame to allow physics to update
        yield return null;

        // Assert that the velocity in the x-direction is equal to the expected value
        Assert.AreEqual(rb.velocity.x, 5f);
    }

    [UnityTest]
    // Test if the player jumps correctly when calling Jump
    public IEnumerator Player_Jump_CorrectJump()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        Rigidbody2D rb = playerObject.AddComponent<Rigidbody2D>();

        // Call the Jump method
        player.Jump();

        // Wait for one frame to allow physics to update
        yield return null;

        // Assert that the velocity in the y-direction is equal to the expected jump force
        Assert.AreEqual(rb.velocity.y, 10f);
    }

    [UnityTest]
    // Test if the player flips correctly when calling FlipCharacter
    public IEnumerator Player_FlipCharacter_CorrectFlip()
    {
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        SpriteRenderer spriteRenderer = playerObject.AddComponent<SpriteRenderer>();

        // Call the FlipCharacter method with a positive horizontal input
        player.FlipCharacter(1f);

        // Wait for one frame to allow rendering to update
        yield return null;

        // Assert that the sprite is not flipped (should face right)
        Assert.IsFalse(spriteRenderer.flipX);

        // Call the FlipCharacter method with a negative horizontal input
        player.FlipCharacter(-1f);

        // Wait for one frame to allow rendering to update
        yield return null;

        // Assert that the sprite is flipped (should face left)
        Assert.IsTrue(spriteRenderer.flipX);
    }
}