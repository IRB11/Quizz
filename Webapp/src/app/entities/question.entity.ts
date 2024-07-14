import { Responses } from "./quizz.entity";

export interface Question {
  id?: number;
  content: string;
  type: string;
  isValid: boolean;
  order: number;
  adminId: number;
  response: Responses[];
  levelId: number;
  technologyId: number;
}

export interface QuestionId {
  id: number;
}
