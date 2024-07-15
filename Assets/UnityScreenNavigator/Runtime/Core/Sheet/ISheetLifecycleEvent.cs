#if USN_USE_ASYNC_METHODS
using System.Threading.Tasks;
#elif USN_USE_UNITASK
using Cysharp.Threading.Tasks;
#else
using System.Collections;
#endif

namespace UnityScreenNavigator.Runtime.Core.Sheet
{
    public interface ISheetLifecycleEvent
    {
#if USN_USE_ASYNC_METHODS
        Task Initialize();
#elif USN_USE_UNITASK
        UniTask Initialize();
#else
        IEnumerator Initialize();
#endif

#if USN_USE_ASYNC_METHODS
        Task WillEnter();
#elif USN_USE_UNITASK
        UniTask WillEnter();
#else
        IEnumerator WillEnter();
#endif
        void DidEnter();

#if USN_USE_ASYNC_METHODS
        Task WillExit();
#elif USN_USE_UNITASK
        UniTask WillExit();
#else
        IEnumerator WillExit();
#endif

        void DidExit();

#if USN_USE_ASYNC_METHODS
        Task Cleanup();
#elif USN_USE_UNITASK
        UniTask Cleanup();
#else
        IEnumerator Cleanup();
#endif
    }
}