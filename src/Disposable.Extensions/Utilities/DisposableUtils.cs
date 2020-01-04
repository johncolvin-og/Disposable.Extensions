using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Disposable.Extensions.Utilities {
   public static class DisposableUtils {
      public static void Dispose<T>(ref T item) where T : class, IDisposable {
         if (item != null) {
            item.Dispose();
            item = null;
         }
      }

      public static void DisposeAndClear<T>([DisallowNull]IList<T> items) where T : IDisposable {
         foreach (var item in items ?? throw new ArgumentNullException(nameof(items)))
            item.Dispose();
         items.Clear();
      }

      public static void DisposeItems<T>([DisallowNull]IEnumerable<T> items) where T : IDisposable {
         foreach (var v in items ?? throw new ArgumentNullException(nameof(items)))
            v.Dispose();
      }
   }
}
