//
// API.cs: definition for the Three20 binding to MonoTouch
//
// Author:
//   Miguel de Icaza (miguel@gnome.org)
// 
using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace MonoTouch.Three20
{
	[BaseType (typeof (UIViewController))]
	interface TTViewController {
		[Export ("navigationBarStyle")]
		UIBarStyle NavigationBarStyle { get; set;  }
		
		[Export ("navigationBarTintColor")]
		UIColor NavigationBarTintColor { get; set;  }
		
		[Export ("statusBarStyle")]
		UIStatusBarStyle StatusBarStyle { get; set;  }
		
		[Export ("searchViewController")]
		TTTableViewController SearchViewController { get; set;  }
		
		[Export ("hasViewAppeared")]
		bool HasViewAppeared { get;  }
		
		[Export ("isViewAppearing")]
		bool IsViewAppearing { get;  }
		
		[Export ("autoresizesForKeyboard")]
		bool AutoresizesForKeyboard { get; set;  }
		
		[Export ("keyboardWillAppear:withBounds:")]
		void KeyboardWillAppearwithBounds (bool animated, RectangleF bounds);
		
		[Export ("keyboardWillDisappear:withBounds:")]
		void KeyboardWillDisappearwithBounds (bool animated, RectangleF bounds);
		
		[Export ("keyboardDidAppear:withBounds:")]
		void KeyboardDidAppearwithBounds (bool animated, RectangleF bounds);
		
		[Export ("keyboardDidDisappear:withBounds:")]
		void KeyboardDidDisappearwithBounds (bool animated, RectangleF bounds);
    }
	
	[BaseType (typeof (TTModelViewController))]
	interface TTTableViewController {
		[Export ("tableView")]
		UITableView TableView { get; set;  }
		
		[Export ("tableBannerView")]
		UIView BannerView { get; set;  }
		
		[Export ("tableOverlayView")]
		UIView OverlayView { get; set;  }
		
		[Export ("loadingView")]
		UIView LoadingView { get; set;  }
		
		[Export ("errorView")]
		UIView ErrorView { get; set;  }
		
		[Export ("emptyView")]
		UIView EmptyView { get; set;  }
		
		[Export ("menuView")]
		UIView MenuView { get;  }
		
		[Export ("dataSource")]
		TTTableViewDataSource DataSource { get; set;  }
		
		[Export ("tableViewStyle")]
		UITableViewStyle TableViewStyle { get; set;  }
		
		[Export ("variableHeightRows")]
		bool VariableHeightRows { get; set;  }
		
		[Export ("initWithStyle:")]
		IntPtr Constructor (UITableViewStyle style);
		
		[Export ("createDelegate")]
		UITableViewDelegate CreateDelegate ();
		
		[Export ("setTableBannerView:animated:")]
		void SetTableBannerView (UIView tableBannerView, bool animated);
		
		[Export ("showMenu:forCell:animated:")]
		void ShowMenuForCell (UIView view, UITableViewCell cell, bool animated);
		
		[Export ("hideMenu:")]
		void HideMenu (bool animated);
		
		[Export ("didSelectObject:atIndexPath:")]
		void DidSelectObjectatIndexPath (NSObject obj, NSIndexPath indexPath);
		
		[Export ("shouldOpenURL:")]
		bool ShouldOpenURL (string url);
		
		[Export ("didBeginDragging")]
		void DidBeginDragging ();
		
		[Export ("didEndDragging")]
		void DidEndDragging ();
		
		[Export ("rectForOverlayView")]
		RectangleF RectForOverlayView ();
		
		[Export ("rectForBannerView")]
		RectangleF RectForBannerView ();
	}	

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTTableViewDataSource {
		[Abstract]
		[Export ("model")]
		TTModel Model { get; set;  }

		[Abstract]
		[Static]
		[Export ("lettersForSectionsWithSearch:summary:")]
		string [] LettersForSections (bool search, bool summary);

		[Abstract]
		[Export ("tableView:objectForRowAtIndexPath:")]
		NSObject ObjectForRowAtIndexPath (UITableView tableView, NSIndexPath indexPath);

		[Abstract]
		[Export ("tableView:cellClassForObject:")]
		Class CellClassForObject (UITableView tableView, NSObject obj);

		[Abstract]
		[Export ("tableView:labelForObject:")]
		string LabelForObject (UITableView tableView, NSObject obj);

		[Abstract]
		[Export ("tableView:indexPathForObject:")]
		NSIndexPath IndexPathForObject (UITableView tableView, NSObject obj);

		[Abstract]
		[Export ("tableView:cell:willAppearAtIndexPath:")]
		void TableViewcellwillAppearAtIndexPath (UITableView tableView, UITableViewCell cell, NSIndexPath indexPath);

		[Abstract]
		[Export ("tableViewDidLoadModel:")]
		void TableViewDidLoadModel (UITableView tableView);

		[Abstract]
		[Export ("titleForLoading:")]
		string TitleForLoading (bool reloading);

		[Abstract]
		[Export ("imageForEmpty")]
		UIImage ImageForEmpty { get; }

		[Abstract]
		[Export ("titleForEmpty")]
		string TitleForEmpty { get; }

		[Abstract]
		[Export ("subtitleForEmpty")]
		string SubtitleForEmpty { get; }

		[Abstract]
		[Export ("imageForError:")]
		UIImage ImageForError (NSError error);

		[Abstract]
		[Export ("titleForError:")]
		string TitleForError (NSError error);

		[Abstract]
		[Export ("subtitleForError:")]
		string SubtitleForError (NSError error);

		[Abstract]
		[Export ("tableView:willUpdateObject:atIndexPath:")]
		NSIndexPath WillUpdateObject (UITableView tableView, NSObject obj, NSIndexPath indexPath);

		[Abstract]
		[Export ("tableView:willInsertObject:atIndexPath:")]
		NSIndexPath WillInsertObject (UITableView tableView, NSObject obj, NSIndexPath indexPath);

		[Abstract]
		[Export ("tableView:willRemoveObject:atIndexPath:")]
		NSIndexPath WillRemoveObject (UITableView tableView, NSObject obj, NSIndexPath indexPath);

		[Abstract]
		[Export ("search:")]
		void Search (string text);
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTModelProtocol {
		[Abstract]
		[Export ("delegates")]
		NSObject [] Delegates { get; }

		[Abstract]
		[Export ("isLoaded")]
		bool IsLoaded { get; }

		[Abstract]
		[Export ("isLoading")]
		bool IsLoading { get; }

		[Abstract]
		[Export ("isLoadingMore")]
		bool IsLoadingMore { get; }

		[Abstract]
		[Export ("isOutdated")]
		bool IsOutdated { get; }

		[Abstract]
		[Export ("load:more:")]
		void Loadmore (TTUrlRequestCachePolicy cachePolicy, bool more);

		[Abstract]
		[Export ("cancel")]
		void Cancel ();

		[Abstract]
		[Export ("invalidate:")]
		void Invalidate (bool erase);
	}

	[BaseType (typeof (NSObject))]
	interface TTModel {
		[Export ("didStartLoad")]
		void DidStartLoad ();

		[Export ("didFinishLoad")]
		void DidFinishLoad ();

		[Export ("didFailLoadWithError:")]
		void DidFailLoadWithError (NSError error);

		[Export ("didCancelLoad")]
		void DidCancelLoad ();

		[Export ("beginUpdates")]
		void BeginUpdates ();

		[Export ("endUpdates")]
		void EndUpdates ();

		[Export ("didUpdateObject:atIndexPath:")]
		void DidUpdateObjectatIndexPath (NSObject obj, NSIndexPath indexPath);

		[Export ("didInsertObject:atIndexPath:")]
		void DidInsertObjectatIndexPath (NSObject obj, NSIndexPath indexPath);

		[Export ("didDeleteObject:atIndexPath:")]
		void DidDeleteObjectatIndexPath (NSObject obj, NSIndexPath indexPath);

		[Export ("didChange")]
		void DidChange ();
	}
	
	[BaseType (typeof (TTViewController))]
	interface TTModelViewController {
		[Export ("model")]
		TTModel Model { get; set;  }

		[Export ("modelError")]
		NSError ModelError { get; set;  }

		[Export ("createModel")]
		void CreateModel ();

		[Export ("invalidateModel")]
		void InvalidateModel ();

		[Export ("isModelCreated")]
		bool IsModelCreated { get; }

		[Export ("shouldLoad")]
		bool ShouldLoad { get; }

		[Export ("shouldReload")]
		bool ShouldReload { get; }

		[Export ("shouldLoadMore")]
		bool ShouldLoadMore { get; }

		[Export ("canShowModel")]
		bool CanShowModel { get; }

		[Export ("reload")]
		void Reload ();

		[Export ("reloadIfNeeded")]
		void ReloadIfNeeded ();

		[Export ("refresh")]
		void Refresh ();

		[Export ("beginUpdates")]
		void BeginUpdates ();

		[Export ("endUpdates")]
		void EndUpdates ();

		[Export ("invalidateView")]
		void InvalidateView ();

		[Export ("updateView")]
		void UpdateView ();

		[Export ("didRefreshModel")]
		void DidRefreshModel ();

		[Export ("willLoadModel")]
		void WillLoadModel ();

		[Export ("didLoadModel:")]
		void DidLoadModel (bool firstTime);

		[Export ("didShowModel:")]
		void DidShowModel (bool firstTime);

		[Export ("showModel:")]
		void ShowModel (bool show);

		[Export ("showLoading:")]
		void ShowLoading (bool show);

		[Export ("showEmpty:")]
		void ShowEmpty (bool show);

		[Export ("showError:")]
		void ShowError (bool show);

	}

	[BaseType (typeof (TTViewController))]
	interface TTMessageController {
		[Export ("delegate"), NullAllowed]
		TTMessageControllerDelegate Delegate { get; set;  }

		[Export ("dataSource"), NullAllowed]
		TTTableViewDataSource DataSource { get; set;  }

		[Export ("fields")]
		TTMessageField [] Fields { get; set;  }

		[Export ("subject")]
		string Subject { get; set;  }

		[Export ("body")]
		string Body { get; set;  }

		[Export ("showsRecipientPicker")]
		bool ShowsRecipientPicker { get; set;  }

		[Export ("isModified")]
		bool IsModified { get;  }

		[Export ("initWithRecipients:")]
		IntPtr Constructor ([NullAllowed] TTMessageRecipientField [] recipients);

		[Export ("addRecipient:forFieldAtIndex:")]
		void AddRecipientforFieldAtIndex (TTMessageRecipientField recipient, int fieldIndex);

		[Export ("textForFieldAtIndex:")]
		string GetTextForFiel (int fieldIndex);

		[Export ("setText:forFieldAtIndex:")]
		void SetTextForField (string text, int fieldIndex);

		[Export ("fieldHasValueAtIndex:")]
		bool FieldHasValue (int fieldIndex);

		[Export ("viewForFieldAtIndex:")]
		UIView ViewForField (int fieldIndex);

		[Export ("showActivityView:")]
		void ShowActivityView (bool show);

		[Export ("titleForSending")]
		string TitleForSending { get; }

		[Export ("send")]
		void Send ();

		[Export ("cancel:")]
		void Cancel (bool confirmIfNecessary);

		[Export ("confirmCancellation")]
		void ConfirmCancellation ();

		[Export ("messageWillSend:")]
		void MessageWillSend (TTMessageTextField [] fields);

		[Export ("messageWillShowRecipientPicker")]
		void MessageWillShowRecipientPicker ();

		[Export ("messageDidSend")]
		void MessageDidSend ();

		[Export ("messageShouldCancel")]
		bool MessageShouldCancel { get; }
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface TTMessageControllerDelegate {
		[Abstract]
		[Export ("composeController:didSendFields:")]
		void ComposeControllerdidSendFields (TTMessageController controller, TTMessageTextField [] fields);

		[Abstract]
		[Export ("composeControllerWillCancel:")]
		void ComposeControllerWillCancel (TTMessageController controller);

		[Abstract]
		[Export ("composeControllerShowRecipientPicker:")]
		void ComposeControllerShowRecipientPicker (TTMessageController controller);
	}

	[BaseType (typeof (NSObject))]
	interface TTMessageField {
		[Export ("title")]
		string Title { get; set;  }

		[Export ("required")]
		bool Required { get; set;  }

		[Export ("initWithTitle:required:")]
		IntPtr Constructor (string title, bool required);

	}

	[BaseType (typeof (TTMessageField))]
	interface TTMessageRecipientField {
		// TODO: we are missing recipients, but we need to figure out the type of the array
		[Export ("recipients")]
		NSArray [] Recipients { get; set; }
	}

	[BaseType (typeof (TTMessageField))]
	interface TTMessageTextField {
		[Export ("text")]
		string Text { get; set;  }
	}

	[BaseType (typeof (TTMessageTextField))]
	interface TTMessageSubjectField {
	}	
}
