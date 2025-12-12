import { BrowserRouter, Routes, Route } from "react-router-dom";
import ClientesList from '../pages/Clientes/ClienteList';
import ClienteDetails from '../pages/Clientes/ClienteDetails';
import ClienteCreate from "../pages/Clientes/ClienteCreate";

export function AppRoutes() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<ClientesList />} />
        <Route path="/clientes/:id" element={<ClienteDetails />} />
        <Route path='/clientes/novo' element={<ClienteCreate />} />

      </Routes>
    </BrowserRouter>
  );
}
