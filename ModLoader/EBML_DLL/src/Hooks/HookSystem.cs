using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBML.Hooks {

    /// <summary>
    /// The base class for all HookSystem classes.
    /// </summary>
    public abstract class HookSystemBase<I> {

        /// <summary>
        /// Setting this to true will skip the original
        /// method this hooks is connected to 
        /// </summary>
        public bool skipOriginalMethod = false;

        /// <summary>
        /// This method will reset <see cref="HookSystemBase{I}.skipOriginalMethod"/>
        /// and return the opposite of it.
        /// </summary>
        /// <returns>Opposite value of <see cref="HookSystemBase{I}.skipOriginalMethod"/> before reset</returns>
        public bool ResetOriginalMethodSkip () {
            if (!skipOriginalMethod)
                return true;

            skipOriginalMethod = false;
            return false;
        }

    }

    /// <summary>
    /// Hook System that registers pre and post hooks.
    /// </summary>
    /// <typeparam name="I">The Instance type.</typeparam>
    public class HookSystem<I> : HookSystemBase<I> {

        private List<System.Action<I>> preHooks = new List<Action<I>>();
        private List<System.Action<I>> postHooks = new List<Action<I>>();

        /// <summary>
        /// Adds a pre hook. This means that the Action will be called
        /// before the original method body code.
        /// </summary>
        /// <param name="preHook">The actual hook</param>
        public void AddPreHook(System.Action<I> preHook) {
            this.preHooks.Add(preHook);
        }

        /// <summary>
        /// Adds a post hook. This means that the Action will be called
        /// after the original method body code, but before it returns anything.
        /// </summary>
        /// <param name="postHook">The actual hook</param>
        public void AddPostHook(System.Action<I> postHook) {
            this.postHooks.Add(postHook);
        }

        /// <summary>
        /// Adds both pre and post hook in one method.
        /// See <see cref="AddPreHook(Action{I})"/>.
        /// See <see cref="AddPostHook(Action{I})"/>.
        /// </summary>
        /// <param name="preHook">The actual pre hook</param>
        /// <param name="postHook">The actual post hook</param>
        public void AddHooks (System.Action<I> preHook, System.Action<I> postHook) {
            if (preHook != null) 
                AddPreHook(preHook);

            if (postHook != null)
                AddPostHook(postHook);
        }

        /// <summary>
        /// Invokes all the pre hooks.
        /// </summary>
        /// <param name="__instance">The instance.</param>
        public void InvokePreHooks (I __instance) {
            preHooks.ForEach(hook => hook.Invoke(__instance));
        }

        /// <summary>
        /// Invokes all the post hooks.
        /// </summary>
        /// <param name="__instance">The instance</param>
        public void InvokePostHooks(I __instance) {
            postHooks.ForEach(hook => hook.Invoke(__instance));
        }

    }

    /// <summary>
    /// Same as <see cref="HookSystem{I}"/>, but with one argument.
    /// </summary>
    /// <typeparam name="I">The instance type.</typeparam>
    /// <typeparam name="A1">The argument.</typeparam>
    public class HookSystem<I, A1> : HookSystemBase<I> {

        private List<System.Action<I, A1>> preHooks = new List<Action<I, A1>>();
        private List<System.Action<I, A1>> postHooks = new List<Action<I, A1>>();

        /// <summary>
        /// See <see cref="HookSystem{I}.AddPreHook(Action{I})"/>.
        /// </summary>
        public void AddPreHook(System.Action<I, A1> preHook) {
            this.preHooks.Add(preHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.AddPostHook(Action{I})"/>.
        /// </summary>
        public void AddPostHook(System.Action<I, A1> postHook) {
            this.postHooks.Add(postHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.AddHooks(Action{I}, Action{I})"/>.
        /// </summary>
        public void AddHooks(System.Action<I, A1> preHook, System.Action<I, A1> postHook) {
            if (preHook != null) 
                AddPreHook(preHook);

            if (postHook != null)
                AddPostHook(postHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.InvokePreHooks(I)"/>
        /// </summary>
        public void InvokePreHooks(I __instance, A1 argument1) {
            preHooks.ForEach(hook => hook.Invoke(__instance, argument1));
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.InvokePostHooks(I)"/>
        /// </summary>
        public void InvokePostHooks(I __instance, A1 argument1) {
            postHooks.ForEach(hook => hook.Invoke(__instance, argument1));
        }

    }

    /// <summary>
    /// Same as <see cref="HookSystem{I}"/>, but with two arguments.
    /// </summary>
    /// <typeparam name="I">The instance type.</typeparam>
    /// <typeparam name="A1">The first argument.</typeparam>
    /// <typeparam name="A2">The second argument.</typeparam>
    public class HookSystem<I, A1, A2> : HookSystemBase<I> {

        private List<System.Action<I, A1, A2>> preHooks = new List<Action<I, A1, A2>>();
        private List<System.Action<I, A1, A2>> postHooks = new List<Action<I, A1, A2>>();

        /// <summary>
        /// See <see cref="HookSystem{I}.AddPreHook(Action{I})"/>.
        /// </summary>
        public void AddPreHook(System.Action<I, A1, A2> preHook) {
            this.preHooks.Add(preHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.AddPostHook(Action{I})"/>.
        /// </summary>
        public void AddPostHook(System.Action<I, A1, A2> postHook) {
            this.postHooks.Add(postHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.AddHooks(Action{I}, Action{I})"/>.
        /// </summary>
        public void AddHooks(System.Action<I, A1, A2> preHook, System.Action<I, A1, A2> postHook) {
            if (preHook != null)
                AddPreHook(preHook);

            if (postHook != null)
                AddPostHook(postHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.InvokePreHooks(I)"/>
        /// </summary>
        public void InvokePreHooks(I __instance, A1 argument1, A2 argument2) {
            preHooks.ForEach(hook => hook.Invoke(__instance, argument1, argument2));
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.InvokePostHooks(I)"/>
        /// </summary>
        public void InvokePostHooks(I __instance, A1 argument1, A2 argument2) {
            postHooks.ForEach(hook => hook.Invoke(__instance, argument1, argument2));
        }

    }

    /// <summary>
    /// Same as <see cref="HookSystem{I}"/>, but with three arguments.
    /// </summary>
    /// <typeparam name="I">The instance type.</typeparam>
    /// <typeparam name="A1">The first argument.</typeparam>
    /// <typeparam name="A2">The second argument.</typeparam>
    /// <typeparam name="A3">The third argument.</typeparam>
    public class HookSystem<I, A1, A2, A3> : HookSystemBase<I> {

        private List<System.Action<I, A1, A2, A3>> preHooks = new List<Action<I, A1, A2, A3>>();
        private List<System.Action<I, A1, A2, A3>> postHooks = new List<Action<I, A1, A2, A3>>();

        /// <summary>
        /// See <see cref="HookSystem{I}.skipOriginalMethod"/>
        /// </summary>
        public bool skipOriginalMethod = false;

        /// <summary>
        /// See <see cref="HookSystem{I}.AddPreHook(Action{I})"/>.
        /// </summary>
        public void AddPreHook(System.Action<I, A1, A2, A3> preHook) {
            this.preHooks.Add(preHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.AddPostHook(Action{I})"/>.
        /// </summary>
        public void AddPostHook(System.Action<I, A1, A2, A3> postHook) {
            this.postHooks.Add(postHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.AddHooks(Action{I}, Action{I})"/>.
        /// </summary>
        public void AddHooks(System.Action<I, A1, A2, A3> preHook, System.Action<I, A1, A2, A3> postHook) {
            if (preHook != null)
                AddPreHook(preHook);

            if (postHook != null)
                AddPostHook(postHook);
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.InvokePreHooks(I)"/>
        /// </summary>
        public void InvokePreHooks(I __instance, A1 argument1, A2 argument2, A3 argument3) {
            preHooks.ForEach(hook => hook.Invoke(__instance, argument1, argument2, argument3));
        }

        /// <summary>
        /// See <see cref="HookSystem{I}.InvokePostHooks(I)"/>
        /// </summary>
        public void InvokePostHooks(I __instance, A1 argument1, A2 argument2, A3 argument3) {
            postHooks.ForEach(hook => hook.Invoke(__instance, argument1, argument2, argument3));
        }

    }

}

