using System;
using System.Linq;

namespace Disposable.Extensions {
   public static class DisposableFactory {
      public static IDisposable Create(Action a) =>
         new AnonymousDisposable(a);

      public static IDisposable Create(params Action[] actions) =>
         Create(actions.Aggregate((a, b) => a + b));

      public static IDisposable Create(params IDisposable[] disposables) {
         if (disposables.Length == 1) return disposables.First();
         return Create(() => {
            foreach (var d in disposables) {
               try {
                  if (d != null)
                     d.Dispose();
               } catch { }
            }
         });
      }
   }
}
