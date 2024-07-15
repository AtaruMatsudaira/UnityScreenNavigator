using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Demo.Subsystem.Misc;
using Demo.Subsystem.PresentationFramework.UnityScreenNavigatorExtensions;

namespace Demo.Subsystem.PresentationFramework
{
    public abstract class ModalPresenter<TModal, TRootView, TRootViewState> : ModalPresenter<TModal>,
        IDisposableCollectionHolder
        where TModal : Modal<TRootView, TRootViewState>
        where TRootView : AppView<TRootViewState>
        where TRootViewState : AppViewState, new()
    {
        private readonly List<IDisposable> _disposables = new List<IDisposable>();

        private TRootViewState _state;

        protected ModalPresenter(TModal view) : base(view)
        {
        }

        ICollection<IDisposable> IDisposableCollectionHolder.GetDisposableCollection()
        {
            return _disposables;
        }

        protected sealed override void Initialize(TModal view)
        {
            base.Initialize(view);
        }

        protected sealed override async UniTask ViewDidLoad(TModal view)
        {
            await base.ViewDidLoad(view);
            var state = new TRootViewState();
            _state = state;
            _disposables.Add(state);
            view.Setup(state);
            await ViewDidLoad(view, _state);
        }

        protected sealed override async UniTask ViewWillPushEnter(TModal view)
        {
            await base.ViewWillPushEnter(view);
            await ViewWillPushEnter(view, _state);
        }

        protected sealed override void ViewDidPushEnter(TModal view)
        {
            base.ViewDidPushEnter(view);
            ViewDidPushEnter(view, _state);
        }

        protected sealed override async UniTask ViewWillPushExit(TModal view)
        {
            await base.ViewWillPushExit(view);
            await ViewWillPushExit(view, _state);
        }

        protected sealed override void ViewDidPushExit(TModal view)
        {
            base.ViewDidPushExit(view);
            ViewDidPushExit(view, _state);
        }

        protected sealed override async UniTask ViewWillPopEnter(TModal view)
        {
            await base.ViewWillPopEnter(view);
            await ViewWillPopEnter(view, _state);
        }

        protected sealed override void ViewDidPopEnter(TModal view)
        {
            base.ViewDidPopEnter(view);
            ViewDidPopEnter(view, _state);
        }

        protected sealed override async UniTask ViewWillPopExit(TModal view)
        {
            await base.ViewWillPopExit(view);
            await ViewWillPopExit(view, _state);
        }

        protected sealed override void ViewDidPopExit(TModal view)
        {
            base.ViewDidPopExit(view);
            ViewDidPopExit(view, _state);
        }

        protected override async UniTask ViewWillDestroy(TModal view)
        {
            await base.ViewWillDestroy(view);
            await ViewWillDestroy(view, _state);
        }

        protected virtual UniTask ViewDidLoad(TModal view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual UniTask ViewWillPushEnter(TModal view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPushEnter(TModal view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillPushExit(TModal view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPushExit(TModal view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillPopEnter(TModal view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPopEnter(TModal view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillPopExit(TModal view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected virtual void ViewDidPopExit(TModal view, TRootViewState viewState)
        {
        }

        protected virtual UniTask ViewWillDestroy(TModal view, TRootViewState viewState)
        {
            return UniTask.CompletedTask;
        }

        protected sealed override void Dispose(TModal view)
        {
            base.Dispose(view);
            foreach (var disposable in _disposables)
                disposable.Dispose();
        }
    }
}
