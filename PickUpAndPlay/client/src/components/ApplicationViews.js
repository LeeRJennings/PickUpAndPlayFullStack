import { Routes, Route, Navigate } from "react-router-dom";
import { AllGames } from "./Games/AllGames";
import Login from "./Login";
import Register from "./Register";
import { Welcome } from "./Welcome";

export default function ApplicationViews({ isLoggedIn }) {
  return (
    <Routes>
      <Route path="/">
        <Route index element={isLoggedIn ? <Welcome /> : <Navigate to="/login" />} />

        <Route path="games">
          <Route index element={isLoggedIn ? <AllGames /> : <Navigate to="/login" />} />
        </Route>
        
        <Route path="login" element={<Login />} />
        <Route path="register" element={<Register />} />
        
        <Route path="*" element={<p>Whoops, nothing here...</p>} />
      </Route>
    </Routes>
  );
}