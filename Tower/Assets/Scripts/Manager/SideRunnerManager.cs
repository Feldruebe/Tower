// <copyright file="SideRunnerManager.cs" company="The Feldruebe">
// Copyright (c) 2012 All Rights Reserved
// </copyright>
// <author>Michael Schneider</author>
// <date>2013/11/16</date>
// <summary>Class representing a Siderunnermanager.</summary>

namespace Tower.Manager
{
    #region Using Directives
    using UnityEngine;
    using System.Collections;
    using Tower.Geometry;
    #endregion // Using Directives

    /// <summary>
    /// Class representing a Siderunnermanager.
    /// </summary>
    public class SideRunnerManager : MonoBehaviour
    {
        public Transform Player;
        public Transform SpawnPoint;
        public GameObject StandardBlock;
        public Camera Camera;

        public float MinBlockSpeed;
        public float MaxBlockSpeed;
        public float MinBlockScale;
        public float MaxBlockScale;
        public float MinBlockPositionZ;
        public float MaxBlockPositionZ;
        public float MinBlockPositionY;
        public float MaxBlockPositionY;

        public float GenerationSpeed;
        public float NextGeneration = 0;

        void Start()
        {

        }

        void Update()
        {
            NextGeneration -= Time.deltaTime;
            if (NextGeneration < 0)
            {
                Vector3 SpanwPositionVariation = new Vector3(0,
                                                            MinBlockPositionY + (MaxBlockPositionY) * Random.value,
                                                            MinBlockPositionZ + (MaxBlockPositionZ) * Random.value);

                GameObject newBlock = (GameObject) Instantiate(StandardBlock, 
                                                               SpawnPoint.position + SpanwPositionVariation,
                                                               Quaternion.identity);

                newBlock.GetComponent<GeometryBlock>().Scale = new Vector3(MinBlockScale + (MaxBlockScale) * Random.value,
                                                            MinBlockScale + (MaxBlockScale) * Random.value,
                                                            MinBlockScale + (MaxBlockScale) * Random.value);
                NextGeneration = GenerationSpeed;
            }
        }
    }
}
