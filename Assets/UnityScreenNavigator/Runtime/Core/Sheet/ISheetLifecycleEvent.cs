#if USN_USE_ASYNC_METHODS
#if USN_USE_UNITASK
using Task = Cysharp.Threading.Tasks.UniTask;
#else 
using Task = System.Threading.Tasks.Task;
#endif
#endif
using System.Collections;

namespace UnityScreenNavigator.Runtime.Core.Sheet
{
    public interface ISheetLifecycleEvent
    {
#if USN_USE_ASYNC_METHODS
        Task Initialize();
#else
        IEnumerator Initialize();
#endif

#if USN_USE_ASYNC_METHODS
        Task WillEnter();
#else
        IEnumerator WillEnter();
#endif
        void DidEnter();

#if USN_USE_ASYNC_METHODS
        Task WillExit();
#else
        IEnumerator WillExit();
#endif

        void DidExit();

#if USN_USE_ASYNC_METHODS
        Task Cleanup();
#else
        IEnumerator Cleanup();
#endif
    }
}