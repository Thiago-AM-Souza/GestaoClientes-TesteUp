import React, { useState, useEffect } from 'react';
import type { Cliente } from '../../models/Cliente';
import { useNavigate } from 'react-router-dom';
import { getClientes } from '../../services/Cliente/clienteService';


const ClientList: React.FC = () => {
  const [clientes, setClientes] = useState<Cliente[]>([]);
  
  const navigate = useNavigate();
  const handleRowClick = (cliente: Cliente) => {
    navigate(`/clientes/${cliente.id}`);
  };
  
  useEffect(() => {
    async function fetchData() {
      try {
        const data = await getClientes();
        setClientes(data);
      } catch (error) {
        console.error('Erro ao carregar clientes:', error);
      }
    }

    fetchData();
  }, []);

  return (
    <div className="container mt-4">
      <div className='d-flex justify-content-between align-items-center mt-4'>
      <h2>Clientes</h2>

      <button
        className='btn btn-primary'
        onClick={() => navigate('/clientes/novo')}
      >
        Adicionar Cliente
      </button>
    </div>

      <table className="table table-striped table-bordered mt-3">
        <thead className="table-dark">
          <tr>
            <th>Nome</th>
            <th>CPF</th>
            <th>Email</th>
            <th>Status</th>
          </tr>
        </thead>

        <tbody>
          {clientes.map(cliente => (
            <tr key={cliente.id}
                className="table-row-clickable"
                onClick={() => handleRowClick(cliente)}
            >
              <td>{cliente.nome}</td>
              <td>{cliente.cpf}</td>
              <td>{cliente.email}</td>
              <td>
                {cliente.ativo ? (
                  <span className="badge bg-success">Ativo</span>
                ) : (
                  <span className="badge bg-secondary">Inativo</span>
                )}
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
};

export default ClientList;
