import api from '../api';
import type { Cliente } from '../../models/Cliente';

export async function getClientes(): Promise<Cliente[]> {
  const response = await api.get<Cliente[]>('/cliente');
  return response.data;
}

export async function getClienteById(id: string): Promise<Cliente> {
  const response = await api.get<Cliente>(`/cliente/${id}`);
  return response.data;
}

export async function createCliente(cliente: Cliente): Promise<Cliente> {
  const response = await api.post<Cliente>('/cliente', cliente);
  return response.data;
}

export async function updateCliente(id: string, cliente: Cliente): Promise<Cliente> {
  const response = await api.put<Cliente>(`/cliente/${id}`, cliente);
  return response.data;
}

export async function statusClienteAtivar(id: string): Promise<void> {
  await api.patch(`/cliente/${id}/ativar`);
}

export async function statusClienteDesativar(id: string): Promise<void> {
  await api.patch(`/cliente/${id}/desativar`);
}


