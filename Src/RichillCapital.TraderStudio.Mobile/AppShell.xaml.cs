using RichillCapital.TraderStudio.Mobile.Views;

namespace RichillCapital.TraderStudio.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("Main", typeof(MainPage));

            Routing.RegisterRoute("Brokerages", typeof(BrokeragesPage));
            Routing.RegisterRoute("BrokeragesDetails", typeof(BrokerageDetailsPage));
            
            Routing.RegisterRoute("DataFeeds", typeof(DataFeedsPage));
            
            Routing.RegisterRoute("SignalSources", typeof(SignalSourcesPage));
        }
    }
}
