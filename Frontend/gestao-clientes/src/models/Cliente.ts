export interface Telefone {
  tipoTelefone: number;
  numero: string;
}

export interface Cliente {
  id: string;
  nome: string;
  cpf: string;
  email: string;
  ativo: boolean;
  telefones: Telefone[];
}
