using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CubeHitpointsTests
{
    [Test]
    [TestCase(0)]
    [TestCase(-5)]
    [TestCase(-0.1f)] // This test case should fail if hitPoints variable is an integer.
    [TestCase(-9999999)]
    public void DisableOnDeath_NoHitPoints_ObjectSetActiveFalse(float hitPoints)
    {
        GameObject testObject = CreateTestCube(hitPoints);

        Assert.IsFalse(testObject.activeSelf);
    }

    [Test]
    [TestCase(5)]
    [TestCase(25)]
    [TestCase(0.1f)] // This test case should fail if hitPoints variable is an integer.
    [TestCase(9999999)]
    public void DisableOnDeath_HasHitPoints_ObjectSetActiveTrue(float hitPoints)
    {
        GameObject testObject = CreateTestCube(hitPoints);

        Assert.IsTrue(testObject.activeSelf);
    }

    private static GameObject CreateTestCube(float hitPoints)
    {
        GameObject testObject = new();
        CubeHitpointsController cubeHitpointsController = testObject.AddComponent<CubeHitpointsController>();

        cubeHitpointsController.hitPoints = hitPoints;
        cubeHitpointsController.DisableOnDeath();
        return testObject;
    }
}