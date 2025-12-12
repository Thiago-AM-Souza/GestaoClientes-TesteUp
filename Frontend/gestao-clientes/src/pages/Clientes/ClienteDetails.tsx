import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import type { Cliente } from '../../models/Cliente';
import { getClienteById, 
         updateCliente,
         statusClienteAtivar,
         statusClienteDesativar } 
from '../../services/Cliente/clienteService';


const ClienteDetails: React.FC = () => {
  const { id } = useParams();
  const navigate = useNavigate();

  const [cliente, setCliente] = useState<Cliente | null>(null);
  const [editMode, setEditMode] = useState(false);
  const [formData, setFormData] = useState<Cliente | null>(null);

  useEffect(() => {
  async function fetchData() {
    try {
      if (!id) return;

      const data = await getClienteById(id);
      setCliente(data);
      setFormData(data);
    } catch (err) {
      console.error(err);
    }
  }
    fetchData();
  }, [id]);

  if (!cliente || !formData) return <div className='container mt-4'>Carregando...</div>;

  const handleChange = <K extends keyof Cliente>(field: K, value: Cliente[K]) => {
    setFormData(prev => prev ? { ...prev, [field]: value } : prev);
  };

  const handleSave = async () => {
    if (!id || !formData) return;

    try {
      const clienteAtualizado = await updateCliente(id, formData);

      setCliente(clienteAtualizado);
      setFormData(clienteAtualizado);

      setEditMode(false);

      alert('Cliente atualizado com sucesso!');
      navigate('/');
    } catch {
      alert('Erro desconhecido ao atualizar cliente.');
    }
  };


  const handleCancel = () => {
    setFormData(cliente);
    setEditMode(false);
  };

  const handleToggleStatus = async () => {
    if (!id || !formData) return;

    const estaAtivo = formData.ativo;

    try {
      if (estaAtivo) {
        await statusClienteDesativar(id);
        alert('Cliente desativado com sucesso!');
      } else {
        await statusClienteAtivar(id);
        alert('Cliente ativado com sucesso!');
      }

      navigate('/');

    } catch {
      alert('Erro desconhecido ao atualizar status.');
    }
  };

  return (
    <div className='container mt-4'>

      {/* Título */}
      <div className='d-flex justify-content-between align-items-center'>
        <h2>Detalhes do Cliente</h2>

        <button
          className='btn btn-secondary'
          onClick={() => navigate('/')}
        >
          Voltar
        </button>
      </div>

      <div className='card mt-3'>
        <div className='card-body'>

          <div className='mb-3'>
            <label className='form-label'>Nome</label>
            <input
              type='text'
              className='form-control'
              value={formData.nome}
              readOnly={!editMode}
              onChange={e => handleChange('nome', e.target.value)}
            />
          </div>

          <div className='mb-3'>
            <label className='form-label'>CPF</label>
            <input
              type='text'
              className='form-control'
              value={formData.cpf}
              readOnly={!editMode}
              onChange={e => handleChange('cpf', e.target.value)}
            />
          </div>

          <div className='mb-3'>
            <label className='form-label'>Email</label>
            <input
              type='email'
              className='form-control'
              value={formData.email}
              readOnly={!editMode}
              onChange={e => handleChange('email', e.target.value)}
            />
          </div>
          {!editMode && (
          <>
            <div className='mb-3'>
              <label className='form-label'>Status</label>
              <input
                type='text'
                className='form-control'
                value={formData.ativo ? 'Ativo' : 'Inativo'}
                readOnly={true}
              />            
            </div>
          
            <div className='mb-3'>
              <label className='form-label d-block'>Telefones</label>

              <ul className='list-group'>
                {formData.telefones.map((t, index) => (
                  <li key={index} className='list-group-item d-flex justify-content-between align-items-center'>
                    
                    <span>
                      <span className='badge bg-primary me-2'>
                        {t.tipoTelefone === 0 ? 'Fixo' : 'Celular'}
                      </span>
                      {t.numero}
                    </span>

                  </li>
                ))}
              </ul>
            </div>
          </>
          )}

          <div className='mt-4 d-flex gap-2'>

            {!editMode && (
              <button
                className='btn btn-primary'
                onClick={() => setEditMode(true)}
              >
                Editar
              </button>
            )}

           {editMode && (
              <>
                <button
                  className='btn btn-success'
                  onClick={handleSave}
                >
                  Salvar
                </button>

                <button
                  className='btn btn-danger'
                  onClick={handleCancel}
                >
                  Cancelar
                </button>

                <button
                  className={`btn ${formData.ativo ? 'btn-warning' : 'btn-primary'}`}
                  onClick={handleToggleStatus}
                >
                  {formData.ativo ? 'Desativar' : 'Ativar'}
                </button>
              </>
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default ClienteDetails;
