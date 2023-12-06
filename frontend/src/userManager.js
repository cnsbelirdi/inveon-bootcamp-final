import { createUserManager } from "redux-oidc";

const userManagerConfig = {
  client_id: "inveon",
  authority: "https://localhost:44365",
  redirect_uri: "http://localhost:5011/callback",
  response_type: "code",
  scope: "openid profile inveon",
  client_secret: "secret",
  post_logout_redirect_uri: "http://localhost:5011/signout-callback-oidc",
  filterProtocolClaims: true,
  loadUserInfo: true,
  monitorSession: true,
};

const userManager = createUserManager(userManagerConfig);

export default userManager;
