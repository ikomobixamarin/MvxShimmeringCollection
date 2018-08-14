// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace MvxShimmeringCollection.iOS
{
	[Register ("ShimmeringTableViewCell")]
	partial class ShimmeringTableViewCell
	{
		[Outlet]
		MvxShimmering.ShimmeringView Root { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (Root != null) {
				Root.Dispose ();
				Root = null;
			}
		}
	}
}
