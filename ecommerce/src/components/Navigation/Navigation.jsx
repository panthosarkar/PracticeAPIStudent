import React from "react";
import "../Navigation/Navigation.css";

function Navigation() {
  return (
    <div className="nav-container">
      <div className="nav-elements">
        <ul>
          <li>
            <h1>WiseBuy</h1>
          </li>
          <li>
            <a href="#">Home</a>
          </li>
          <li>
            <a href="#">Shop</a>
          </li>
          <li>
            <a href="#">Contact</a>
          </li>
          <li>
            <a href="#">About</a>
          </li>
          <li>
            <a href="#">
              <span class="material-symbols-outlined">shopping_cart</span>
            </a>
          </li>
          <li>
            <a href="#">
              <span class="material-symbols-outlined">person</span>
            </a>
          </li>
        </ul>
      </div>
    </div>
  );
}

export default Navigation;
