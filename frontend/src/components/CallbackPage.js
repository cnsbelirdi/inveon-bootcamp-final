import * as React from "react";
import { connect, useDispatch } from "react-redux";
import userManager from "./../userManager";
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";
import { fetchCart } from "../app/slices/product";

const CallbackPage = () => {
  const navigate = useNavigate();
  const dispatch = useDispatch();

  const successCallback = (user) => {
    // get the user's previous location, passed during signinRedirect()
    const redirectPath = user.state.path;
    const userProfile = {
      name: user.profile.name,
      role: user.profile.role,
      email: user.profile.preferred_username,
      id: user.profile.sub,
    };
    dispatch({
      type: "user/login",
      payload: { user: userProfile, status: true },
    });

    const getCart = async () => {
      await dispatch(fetchCart(userProfile.id));
    };
    getCart();
    navigate(redirectPath);
  };

  const errorCallback = (error) => {
    console.log(error);
    navigate("/");
  };

  useEffect(() => {
    userManager
      .signinRedirectCallback()
      .then((user) => successCallback(user))
      .catch((error) => errorCallback(error));
  });

  return <div>Loading...</div>;
};

export default connect()(CallbackPage);
