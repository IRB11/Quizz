export interface Quizz {
    id: number;
    candidateId: number;
    agentId: number;
    technologyId: number;
    adminId: any;

    comment: string;
    completionLevel: number;
    completionTime: Date;
    isValid: boolean;
    numberOfQuestion: number;
    quizzNumber: string;
    result: number;
    url: string;
    
    agent: any;
    admin: any;
    candidate: any;
    statusId: number;
    status: any;
    levelId: number;
    level: any;
    technologies: any;
}

export interface Responses {
  // Define the properties of ResponseRequest here        public long? Id { get; set; }
        id: number;
        content: string;
        explanation: string;
        isCorrect: boolean;
}
export interface savedResponses {

        id?: number;
        content: string;
        isSkipped: boolean;
        openResponseText: string;
        comment: string;
        responseId: number;
        quizId?: number;
        questionId?: number;
  }
  