using System;
using RimWorld;
using UnityEngine;
using Verse;

namespace ColonistBarBelowDev {
	public class ModMain : Mod {
		public Settings Settings => GetSettings<Settings>();
		public ModMain(ModContentPack content) : base(content) { }

		public override string SettingsCategory() {
			return Content.Name;
		}
		public override void DoSettingsWindowContents(Rect inRect) {
			Listing_Standard listing = new Listing_Standard();
			listing.Begin(inRect);
			string label = "Foxy.ColonistBarBelowDev.Offset".Translate().Trim();
			float value = Settings.offset;
			string buffer = value.ToString();
			listing.TextFieldNumericLabeled(label, ref value, ref buffer, 0, UI.screenHeight / 4);
			if(value != Settings.offset && Find.UIRoot is UIRoot_Play root) {
				root.mapUI.colonistBar.MarkColonistsDirty();
			}
			Settings.offset = (float)Math.Round(value);
			listing.End();
		}
	}
}
