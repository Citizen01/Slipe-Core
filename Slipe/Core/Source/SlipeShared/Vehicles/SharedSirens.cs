﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using Slipe.MTADefinitions;
using Slipe.Shared.Utilities;

namespace Slipe.Shared.Vehicles
{
    /// <summary>
    /// Represents the set of all sirens on a vehicle
    /// </summary>
    public class SharedSirens
    {
        protected SharedVehicle vehicle;

        #region Properties
        protected SirenType type;
        /// <summary>
        /// Get the type of this siren set
        /// </summary>
        public SirenType Type
        {
            get
            {
                return type;
            }
        }

        protected bool visibleFromAllDirection;
        /// <summary>
        /// Visible from all directions (applies to single type only)
        /// </summary>
        public bool VisibleFromAllDirections
        {
            get
            {
                return visibleFromAllDirection;
            }
        }

        protected bool checkLOS;
        /// <summary>
        /// Check line of sight between camera and light so it won't draw if blocked
        /// </summary>
        public bool CheckLineOfSight
        {
            get
            {
                return checkLOS;
            }
        }

        protected bool useRandomiser;
        /// <summary>
        /// Randomise the light order, false for sequential
        /// </summary>
        public bool UseRandomiser
        {
            get
            {
                return useRandomiser;
            }
        }

        protected bool silent;
        /// <summary>
        /// If the silent is silent (no audio) or not
        /// </summary>
        public bool Silent
        {
            get
            {
                return silent;
            }
        }

        /// <summary>
        /// Get and set if the sirens are on
        /// </summary>
        public bool On
        {
            get
            {
                return MTAShared.GetVehicleSirensOn(vehicle.MTAElement);
            }
            set
            {
                // This is due to an MTA bug not turning on silent sirens that are off
                MTAShared.SetVehicleSirensOn(vehicle.MTAElement, false);
                MTAShared.SetVehicleSirensOn(vehicle.MTAElement, value);
            }
        }

        /// <summary>
        /// Get all the attached individual sirens
        /// </summary>
        public Siren[] All
        {
            get
            {
                dynamic[] ar = MTAShared.GetArrayFromTable(MTAShared.GetVehicleSirens(vehicle.MTAElement), "dynamic");
                Siren[] result = new Siren[ar.Length];
                for (int i = 0; i < ar.Length; i++)
                {
                    Dictionary<string, float> d = (Dictionary<string, float>)MTAShared.GetDictionaryFromTable(ar[i], "System.String", "System.Single");
                    result[i] = new Siren(vehicle, i + 1, new Vector3(d["x"], d["y"], d["z"]), new Color((byte)d["Red"], (byte)d["Green"], (byte)d["Blue"], (byte)d["Alpha"]), d["Min_Alpha"], false);
                }
                return result;
            }
        }
        #endregion

        /// <summary>
        /// Create a sirens set attached to a vehicle
        /// </summary>
        public SharedSirens(SharedVehicle vehicle)
        {
            this.vehicle = vehicle;
            UpdateParams();
        }       

        protected void UpdateParams()
        {
            Dictionary<string, dynamic> d = MTAShared.GetDictionaryFromTable(MTAShared.GetVehicleSirenParams(vehicle.MTAElement), "System.String", "dynamic");
            type = (SirenType)d["SirenType"];
            Dictionary<string, bool> flags = MTAShared.GetDictionaryFromTable(d["Flags"], "System.String", "System.Boolean");
            visibleFromAllDirection = flags["360"];
            checkLOS = flags["DoLOSCheck"];
            useRandomiser = flags["UseRandomiser"];
            silent = flags["Silent"];
        }
    }
}