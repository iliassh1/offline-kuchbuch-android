package md542f6d4e6c5e3dfd51592a8ba34c23e0a;


public class Italien
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("KochBuch.Italien, KochBuch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Italien.class, __md_methods);
	}


	public Italien () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Italien.class)
			mono.android.TypeManager.Activate ("KochBuch.Italien, KochBuch, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
