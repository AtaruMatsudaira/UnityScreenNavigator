using System.Collections;
#if USN_USE_ASYNC_METHODS
using System.Threading.Tasks;
#elif USN_USE_UNITASK
using Cysharp.Threading.Tasks;
#endif

namespace UnityScreenNavigator.Runtime.Core.Page
{
    public interface IPageLifecycleEvent
    {
#if USN_USE_ASYNC_METHODS
        Task Initialize();
#elif USN_USE_UNITASK
        UniTask Initialize();
#else
        IEnumerator Initialize();
#endif

#if USN_USE_ASYNC_METHODS
        Task WillPushEnter();
#elif USN_USE_UNITASK
        UniTask WillPushEnter();

#else
        IEnumerator WillPushEnter();
#endif

        void DidPushEnter();

#if USN_USE_ASYNC_METHODS
        Task WillPushExit();

#elif USN_USE_UNITASK
        UniTask WillPushExit();

#else
        IEnumerator WillPushExit();
#endif

        void DidPushExit();

#if USN_USE_ASYNC_METHODS
        Task WillPopEnter();

#elif USN_USE_UNITASK
        UniTask WillPopEnter();

#else
        IEnumerator WillPopEnter();
#endif

        void DidPopEnter();

#if USN_USE_ASYNC_METHODS
        Task WillPopExit();
#elif USN_USE_UNITASK
        UniTask WillPopExit();
#else
        IEnumerator WillPopExit();
#endif

        void DidPopExit();

#if USN_USE_ASYNC_METHODS
        Task Cleanup();
#elif USN_USE_UNITASK
        UniTask Cleanup();
#else
        IEnumerator Cleanup();
#endif
    }
}