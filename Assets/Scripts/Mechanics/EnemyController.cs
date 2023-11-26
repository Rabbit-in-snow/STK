using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// A simple controller for enemies. Provides movement control over a patrol path.
    /// </summary>
    [RequireComponent(typeof(AnimationController), typeof(Collider2D))]
    public class EnemyController : MonoBehaviour
    {
        public PatrolPath path;
        public AudioClip ouch;
        public int hurtpower=1;
        public int health=1;

        internal PatrolPath.Mover mover;
        internal AnimationController control;
        internal Collider2D _collider;
        internal AudioSource _audio;
        internal GameObject player;
        SpriteRenderer spriteRenderer;

        public Bounds Bounds => _collider.bounds;

        void Awake()
        {
            control = GetComponent<AnimationController>();
            _collider = GetComponent<Collider2D>();
            _audio = GetComponent<AudioSource>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            player = GameObject.Find("Player");
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.collider.gameObject.CompareTag("Player"))
            {
                if (player.GetComponent<player>().attacking == true)
                {
                    health--;
                }
                else
                {
                        StartCoroutine(player.GetComponent<player>().hurt(hurtpower));
                }
            }
        }

        void Update()
        {
            if (path != null)
            {
                if (mover == null) mover = path.CreateMover(control.maxSpeed * 0.5f);
                control.move.x = Mathf.Clamp(mover.Position.x - transform.position.x, -1, 1);
            }
            if (health<=0)
            {
                gameObject.SetActive(false);
            }
        }

    }
}