import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import type { Cliente, Telefone } from '../../models/Cliente';
import { createCliente } from '../../services/Cliente/clienteService';

const ClienteCreate: React.FC = () => {
  const navigate = useNavigate();

  const [formData, setFormData] = useState<Cliente>({
    id: '',
    nome: '',
    cpf: '',
    email: '',
    ativo: true,
    telefones: [] as Telefone[]
  });

  const handleChange = <K extends keyof Cliente>(field: K, value: Cliente[K]) => {
    setFormData(prev => ({ ...prev, [field]: value }));
  };

  const addTelefone = () => {
    setFormData(prev => ({
      ...prev,
      telefones: [...prev.telefones, { tipoTelefone: 0, numero: '' }]
    }));
  };

  const removeTelefone = (index: number) => {
    setFormData(prev => ({
      ...prev,
      telefones: prev.telefones.filter((_, i) => i !== index)
    }));
  };

  const updateTelefone = <K extends 'tipoTelefone' | 'numero'
      >(index: number, field: K, value: Telefone[K]) => {
    setFormData(prev => ({
      ...prev,
      telefones: prev.telefones.map((t, i) =>
        i === index ? { ...t, [field]: value } : t
      )
    }));
  };


  const handleSave = async () => {
    try {
      console.log('Enviando cliente:', formData);

      await createCliente(formData);

      navigate('/');
    } catch (error) {
      alert('Ocorreu um erro ao salvar o cliente: ' + error);
    }
  };

  return (
    <div className='container mt-4'>
      <div className='d-flex justify-content-between align-items-center'>
        <h2>Novo Cliente</h2>

        <button className='btn btn-secondary' onClick={() => navigate('/clientes')}>
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
              onChange={e => handleChange('nome', e.target.value)}
            />
          </div>

          <div className='mb-3'>
            <label className='form-label'>CPF</label>
            <input
              type='text'
              className='form-control'
              value={formData.cpf}
              onChange={e => handleChange('cpf', e.target.value)}
            />
          </div>

          <div className='mb-3'>
            <label className='form-label'>Email</label>
            <input
              type='email'
              className='form-control'
              value={formData.email}
              onChange={e => handleChange('email', e.target.value)}
            />
          </div>

          <div className='mb-3'>
            <label className='form-label d-block'>Telefones</label>

            {formData.telefones.map((t, index) => (
              <div key={index} className='card p-3 mb-2'>
                <div className='row gy-2'>

                  <div className='col-md-3'>
                    <label className='form-label'>Tipo</label>
                    <select
                      className='form-select'
                      value={t.tipoTelefone}
                      onChange={e =>
                        updateTelefone(index, 'tipoTelefone', Number(e.target.value))
                      }
                    >
                      <option value={0}>Fixo</option>
                      <option value={1}>Celular</option>
                    </select>
                  </div>

                  <div className='col-md-7'>
                    <label className='form-label'>Número</label>
                    <input
                      type='text'
                      className='form-control'
                      value={t.numero}
                      onChange={e => updateTelefone(index, 'numero', e.target.value)}
                    />
                  </div>

                  <div className='col-md-2 d-flex align-items-end'>
                    <button
                      className='btn btn-danger w-100'
                      onClick={() => removeTelefone(index)}
                    >
                      Remover
                    </button>
                  </div>

                </div>
              </div>
            ))}

            <button className='btn btn-primary mt-2' onClick={addTelefone}>
              Adicionar Telefone
            </button>
          </div>

          <div className='mt-4'>
            <button className='btn btn-success' onClick={handleSave}>
              Salvar Cliente
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ClienteCreate;