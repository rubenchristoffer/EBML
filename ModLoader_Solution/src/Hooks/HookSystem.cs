using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.Hooks {

    public class HookSystem<I> {

        private List<System.Action<I>> preHooks = new List<Action<I>>();
        private List<System.Action<I>> postHooks = new List<Action<I>>();

        public void AddPreHook(System.Action<I> preHook) {
            this.preHooks.Add(preHook);
        }

        public void AddPostHook(System.Action<I> postHook) {
            this.postHooks.Add(postHook);
        }

        public void AddHooks (System.Action<I> preHook, System.Action<I> postHook) {
            if (preHook != null) AddPreHook(preHook);
            AddPostHook(postHook);
        }

        public void InvokePreHooks (I __instance) {
            preHooks.ForEach(hook => hook.Invoke(__instance));
        }

        public void InvokePostHooks(I __instance) {
            postHooks.ForEach(hook => hook.Invoke(__instance));
        }

    }

    public class HookSystem<I, A1> {

        private List<System.Action<I, A1>> preHooks = new List<Action<I, A1>>();
        private List<System.Action<I, A1>> postHooks = new List<Action<I, A1>>();

        public void AddPreHook(System.Action<I, A1> preHook) {
            this.preHooks.Add(preHook);
        }

        public void AddPostHook(System.Action<I, A1> postHook) {
            this.postHooks.Add(postHook);
        }

        public void AddHooks(System.Action<I, A1> preHook, System.Action<I, A1> postHook) {
            if (preHook != null) AddPreHook(preHook);
            AddPostHook(postHook);
        }

        public void InvokePreHooks(I __instance, A1 argument1) {
            preHooks.ForEach(hook => hook.Invoke(__instance, argument1));
        }

        public void InvokePostHooks(I __instance, A1 argument1) {
            postHooks.ForEach(hook => hook.Invoke(__instance, argument1));
        }

    }

    public class HookSystem<I, A1, A2> {

        private List<System.Action<I, A1, A2>> preHooks = new List<Action<I, A1, A2>>();
        private List<System.Action<I, A1, A2>> postHooks = new List<Action<I, A1, A2>>();

        public void AddPreHook(System.Action<I, A1, A2> preHook) {
            this.preHooks.Add(preHook);
        }

        public void AddPostHook(System.Action<I, A1, A2> postHook) {
            this.postHooks.Add(postHook);
        }

        public void AddHooks(System.Action<I, A1, A2> preHook, System.Action<I, A1, A2> postHook) {
            if (preHook != null) AddPreHook(preHook);
            AddPostHook(postHook);
        }

        public void InvokePreHooks(I __instance, A1 argument1, A2 argument2) {
            preHooks.ForEach(hook => hook.Invoke(__instance, argument1, argument2));
        }

        public void InvokePostHooks(I __instance, A1 argument1, A2 argument2) {
            postHooks.ForEach(hook => hook.Invoke(__instance, argument1, argument2));
        }

    }

}

