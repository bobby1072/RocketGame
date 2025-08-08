import { createContext, useContext } from "react";
import PokeGameCoreHttpClient from "../utils/PokeGameCoreHttpClient";
import { useGetAppSettingsContext } from "./AppSettingsContext";

export const PokeGameCoreHttpClientContext = createContext<
    PokeGameCoreHttpClient | undefined
>(undefined);

export const useGetPokeGameHttpClientContext = () => {
    const value = useContext(PokeGameCoreHttpClientContext);

    if (!value) {
        throw new Error("No settings registered");
    }

    return value;
};

export const PokeGameCoreHttpClientContextProvider: React.FC<{
    children: React.ReactNode;
}> = ({ children }) => {
    const settings = useGetAppSettingsContext();

    return (
        <PokeGameCoreHttpClientContext.Provider
            value={new PokeGameCoreHttpClient(settings.pokeGameCoreApiUrl)}
        >
            {children}
        </PokeGameCoreHttpClientContext.Provider>
    );
};
