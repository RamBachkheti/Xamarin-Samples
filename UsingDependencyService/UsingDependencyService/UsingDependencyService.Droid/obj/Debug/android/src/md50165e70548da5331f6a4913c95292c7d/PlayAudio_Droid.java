package md50165e70548da5331f6a4913c95292c7d;


public class PlayAudio_Droid
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("UsingDependencyService.Droid.PlayAudio_Droid, UsingDependencyService.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PlayAudio_Droid.class, __md_methods);
	}


	public PlayAudio_Droid () throws java.lang.Throwable
	{
		super ();
		if (getClass () == PlayAudio_Droid.class)
			mono.android.TypeManager.Activate ("UsingDependencyService.Droid.PlayAudio_Droid, UsingDependencyService.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
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
