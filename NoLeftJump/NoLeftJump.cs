using HarmonyLib;
using NeosModLoader;
using FrooxEngine;

namespace NoLeftJump
{
	public class NoLeftJump : NeosMod
	{
		public override string Name => "NoLeftJump";
		public override string Author => "eia485";
		public override string Version => "1.0.0";
		public override string Link => "https://github.com/EIA485/NeosNoLeftJump/";
		public override void OnEngineInit()
		{
			Harmony harmony = new Harmony("net.eia485.NoLeftJump");
			harmony.PatchAll();
		}

		[HarmonyPatch(typeof(DualControllerBindingGenerator), "BindJump")]
		class NoLeftJumpPatch
        {
			static bool Prefix(InputGroup group, IDualBindingController right, ref AnyInput __result)
            {
				AnyInput anyInput = new AnyInput();
				right?.BindNodeActions(group, anyInput, "Jump");
				__result = anyInput;
				return false;
			}
        }
	}
}