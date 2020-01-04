using System;

namespace Disposable.Extensions {
   class AnonymousDisposable : IDisposable {
      readonly Action _action;

      public AnonymousDisposable(Action action) =>
         _action = action;

      public void Dispose() =>
         _action?.Invoke();
   }
}
