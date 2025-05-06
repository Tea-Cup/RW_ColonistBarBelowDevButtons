using System.Linq;
using HarmonyLib;
using Verse;

namespace ColonistBarBelowDev {
	public static class ModCompatibility {
		public static bool IsModActive(string packageId) {
			packageId = packageId.ToLower();
			return ModLister.AllInstalledMods.Any(x => x.Active && x.SamePackageId(packageId, true));
		}

		public static bool LTOColonyGroupsFinal => IsModActive("DerekBickley.LTOColonyGroupsFinal");

		public static void PatchAll(Harmony h) {
			if (LTOColonyGroupsFinal) Patch_Mod_LTOColonyGroupsFinal.PatchAll(h);
		}
	}
}
