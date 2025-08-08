import axios, { AxiosInstance } from "axios";
import { SaveUserInput } from "../../models/SaveUserInput";
import { PokeGameUser } from "../../models/PokeGameUser";
import { WebOutcome } from "../../models/WebOutcome";

export default class PokeGameCoreHttpClient {
    private readonly _axiosClient: AxiosInstance;

    public constructor(baseURL: string) {
        this._axiosClient = axios.create({
            baseURL,
        });
    }
    public async SaveUser(
        input: SaveUserInput
    ): Promise<PokeGameUser | null | undefined> {
        const { data } = await this._axiosClient.post<WebOutcome<PokeGameUser>>(
            "Api/User/SaveUser",
            input
        );

        if (!data.isSuccess) {
            throw new Error(data.exceptionMessage || "Error occurred");
        }

        return data.data;
    }
}
