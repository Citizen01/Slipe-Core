﻿using Slipe.Shared;
using Slipe.MTADefinitions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Slipe.Server
{
    public class RPCManager
    {
        private static RPCManager instance;
        public static RPCManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RPCManager();
                }
                return instance;
            }
        }

        private Dictionary<string, Action<Player, object>> RegisteredRPCs;

        private RPCManager()
        {
            RegisteredRPCs = new Dictionary<string, Action<Player, object>>();

            Element.OnRootEvent += (string eventName, MTAElement source, dynamic p1, dynamic p2, dynamic p3, dynamic p4, dynamic p5, dynamic p6, dynamic p7, dynamic p8) =>
            {
                if (RegisteredRPCs.ContainsKey(eventName))
                {
                    Player element = (Player) ElementManager.Instance.GetElement(source);
                    RegisteredRPCs[eventName].Invoke(element, p1);
                }
            };
        }

        public void RegisterRPC<CallbackType>(string key, Action<Player, CallbackType> callback)
        {
            RegisteredRPCs[key] = (Player player, object parameters) => {
                callback.Invoke(player, (CallbackType)parameters);
            };
            MTAShared.AddEvent(key, true);
            Element.Root.AddEventHandler(key);
        }

        public void TriggerRPC(Player target, string key, object argument)
        {
            MTAServer.TriggerClientEvent(target.MTAElement, key, Element.Root.MTAElement, argument);
        }

        public void TriggerRPC(string key, object argument)
        {
            MTAServer.TriggerClientEvent(Element.Root.MTAElement, key, Element.Root.MTAElement, argument);
        }
    }
}