using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class PlayerControllerTests
{
    [Test]
    public void TakeDamage_Deal10DamageToPlayer_HealthIs90()
    {
        PlayerController playerController = CreateTestPlayer();

        playerController.TakeDamage(10);

        Assert.AreEqual(90, playerController.GetHealth());
    }

    [Test]
    [TestCase(100)]
    [TestCase(500)]
    [TestCase(99999)]
    public void KillPlayer_PlayerTakesMoreDamangeThanHealth_PlayerIsDead(float damageAmount)
    {
        PlayerController playerController = CreateTestPlayer();
        playerController.TakeDamage(damageAmount);

        playerController.KillPlayer();

        Assert.IsTrue(playerController.IsPlayerDead());
    }

    [Test]
    public void HealPlayer_Heal50HealthPlayerBy10Health_PlayerHas60Health()
    {
        PlayerController playerController = CreateTestPlayer();
        playerController.TakeDamage(50);

        playerController.HealPlayer(10);

        Assert.AreEqual(60, playerController.GetHealth());
    }

    [Test]
    [TestCase(100)]
    [TestCase(500)]
    [TestCase(99999)]
    public void HealPlayer_HealMoreThanMaxHealth_PlayerHas100Health(float healAmount)
    {
        PlayerController playerController = CreateTestPlayer();
        playerController.TakeDamage(50);

        playerController.HealPlayer(healAmount);

        Assert.AreEqual(100, playerController.GetHealth());
    }

    [Test]
    [TestCase(100)]
    [TestCase(500)]
    [TestCase(99999)]
    [TestCase(-10)]
    public void HealPlayer_HealDeadPlayer_PlayerHas0Health(float healAmount)
    {
        PlayerController playerController = CreateTestPlayer();
        playerController.TakeDamage(100);
        playerController.KillPlayer();

        playerController.HealPlayer(healAmount);

        Assert.AreEqual(0, playerController.GetHealth());
    }

    private static PlayerController CreateTestPlayer()
    {
        PlayerController playerController = new();
        playerController.InitializePlayer();

        return playerController;
    }
}
