using LaunchDarkly.Client;
using Microsoft.Extensions.Configuration;

namespace ModernUIApp.Services {
    public class FeatureFlagServiceService : IFeatureFlagService {
        string _ldkey;
        LdClient _ldClient;
        User _ldUser;
       public FeatureFlagServiceService(IConfiguration configuration)
       {
            _ldkey = configuration.GetValue<string> ("LauchDarklyKey");
            _ldClient = new LdClient(_ldkey);
       }
        public bool ViewFeature (string Username) {
            _ldUser = new LaunchDarkly.Client.User(Username);
            var viewFeature = _ldClient.BoolVariation("ff-customer-management", _ldUser, false);
            return viewFeature;
        }
    }
}