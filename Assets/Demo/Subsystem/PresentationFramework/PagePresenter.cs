using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Demo.Subsystem.Misc;
using Demo.Subsystem.PresentationFramework.UnityScreenNavigatorExtensions;

namespace Demo.Subsystem.PresentationFramework
{
    public abstract class PagePresenter<TPage, TRootView, TRootViewState> : PagePresenter<TPage>,
        IDisposableCollectionHolder
        where TPage : Page<TRootView, TRootViewState>
        where TRootView : AppView<TRootViewState>
        where TRootViewState : AppViewState, new()
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();
        private TRootViewState _state;

        protected PagePresenter(TPage view) : base(view)
        {
        }

        ICollection<IDisposable> IDisposableCollectionHolder.GetDisposableCollection()
        {
            return _disposables;
        }

        protected sealed override void Initialize(TPage view)
        {
            base.Initialize(view);
        }

        protected sealed override async UniTask ViewDidLoad(TPage view)
        {
            await base.ViewDidLoad(view);
            var state = new TRootViewState();
            _state = state;
            _disposables.Add(state);
            view.Setup(state);
            await ViewDidLoad(view, _state);
        }

        protected sealed override async UniTask ViewWillPushEnter(TPage view)
        {
            await base.ViewWillPushEnter(view);
            await ViewWillPushEnter(view, _state);
        }

        protected sealed override void ViewDidPushEnter(TPage view)
        {
            base.ViewDidPushEnter(view);
            ViewDidPushEnter(view, _state);
        }

        protected sealed override async UniTask ViewWillPushExit(TPage view)
        {
            await base.ViewWillPushExit(view);
            await ViewWillPushExit(view, _state);
        }

        protected sealed override void ViewDidPushExit(TPage view)
        {
            base.ViewDidPushExit(view);
            ViewDidPushExit(view, _state);
        }

        protected sealed override async UniTask ViewWillPopEnter(TPage view)
        {
            await base.ViewWillPopEnter(view);
            await ViewWillPopEnter(view, _state);
        }

        protected sealed override void ViewDidPopEnter(TPage view)
        {
            base.ViewDidPopEnter(view);
            ViewDidPopEnter(view, _state);
        }

        protected sealed override async UniTask ViewWillPopExit(TPage view)
        {
            await base.ViewWillPopExit(view);
            await ViewWillPopExit(view, _state);
        }

        protected sealed override void ViewDidPopExit(TPage view)
        {
            base.ViewDidPopExit(view);
            ViewDidPopExit(view, _state);
        }

        protected override async UniTask ViewWillDestroy(TPage view)
        {
            await base.ViewWillDestroy(view);
            await ViewWillDestroy(view, _state);
        }

        protected virtual UniTask ViewDidLoad(TPage view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask ViewWillPushEnter(TPage view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPushEnter(TPage view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillPushExit(TPage view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPushExit(TPage view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillPopEnter(TPage view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPopEnter(TPage view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillPopExit(TPage view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPopExit(TPage view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillDestroy(TPage view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected sealed override void Dispose(TPage view)
        {
            base.Dispose(view);
            foreach (var disposable in _disposables)
                disposable.Dispose();
        }
    }
}
