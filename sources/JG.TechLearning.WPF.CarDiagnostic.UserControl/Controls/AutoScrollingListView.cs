using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JG.TechLearning.WPF.CarDiagnostic.UserControlNS.Controls
{
    public class AutoScrollingListView : ListView
    {
        public AutoScrollingListView()
        {
            _scrollViewer = null;
        }

        private ScrollViewer _scrollViewer;

        protected override void OnItemsSourceChanged(System.Collections.IEnumerable oldValue, System.Collections.IEnumerable newValue)
        {
            base.OnItemsSourceChanged(oldValue, newValue);

            if (oldValue as INotifyCollectionChanged != null)
            {
                (oldValue as INotifyCollectionChanged).CollectionChanged -= OnItemsCollectionChanged;
            }

            if (newValue as INotifyCollectionChanged == null)
            {
                return;
            }

            (newValue as INotifyCollectionChanged).CollectionChanged += OnItemsCollectionChanged;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _scrollViewer = RecursiveVisualChildFinder<ScrollViewer>(this) as ScrollViewer;
        }

        private void OnItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (_scrollViewer == null)
            {
                return;
            }

            UpdateLayout();
            _scrollViewer.ScrollToBottom();
        }

        private static DependencyObject RecursiveVisualChildFinder<T>(DependencyObject rootObject)
        {
            var child = VisualTreeHelper.GetChild(rootObject, 0);
            if (child == null)
            {
                return null;
            }

            return child.GetType() == typeof(T) ? child : RecursiveVisualChildFinder<T>(child);
        }
    }

}
