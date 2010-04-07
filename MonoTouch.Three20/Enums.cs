using System;
using MonoTouch.Foundation;

namespace MonoTouch.Three20 {
	
	public enum TTUrlRequestCachePolicy {
		TTURLRequestCachePolicyNone    = 0,
		TTURLRequestCachePolicyMemory  = 1,
		TTURLRequestCachePolicyDisk    = 2,
		TTURLRequestCachePolicyNetwork = 4,
		TTURLRequestCachePolicyNoCache = 8,    
		TTURLRequestCachePolicyLocal
		= (TTURLRequestCachePolicyMemory | TTURLRequestCachePolicyDisk),
		TTURLRequestCachePolicyDefault
		= (TTURLRequestCachePolicyMemory | TTURLRequestCachePolicyDisk
		   | TTURLRequestCachePolicyNetwork),
	}

}
