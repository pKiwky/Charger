using System.Security.Claims;

namespace Charger.WebAPI.Common {

    public static class UserManager {
        public static int GetUserId(this HttpContext context) {
            var data = context.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (data == null) {
                return 0;
            }

            return Convert.ToInt32(data.Value);
        }
    }

}
