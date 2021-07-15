import { ConsumerBenefitResult } from "./ConsumerBenefitResult";

export class ConsumerProfile{
    id: string = "";
    consumerName: string = "";
    basicSalary: number = 0;
    birthdate: Date = new Date();
    birthdateStr: string = "";
    consumerBenefitResults: ConsumerBenefitResult[] = [];
}