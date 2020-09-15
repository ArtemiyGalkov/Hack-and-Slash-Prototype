﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationOverrider : MonoBehaviour
{
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void SetAnimations(AnimatorOverrideController overrideController)
    {
        _animator.runtimeAnimatorController = overrideController;
    }
}