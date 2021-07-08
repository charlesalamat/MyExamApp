import { ConsumerBenefitResult } from "./ConsumerBenefitResult";

export class ConsumerProfile{
    consumerName: string = "";
    basicSalary: number = 0;
    birthdate: Date = new Date();
    consumerBenefitResults: ConsumerBenefitResult[] = [];
}