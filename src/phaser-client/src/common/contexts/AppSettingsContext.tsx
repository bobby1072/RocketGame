import { createContext, useContext } from "react";
import AppSettingsProvider, { AppSettings } from "../utils/AppSettingsProvider";

const AppSettingsContext = createContext<AppSettings | undefined>(undefined);

export const useGetAppSettingsContext = () => {
    const value = useContext(AppSettingsContext);

    if (!value) {
        throw new Error("No settings registered");
    }

    return value;
};

export const AppSettingsContextProvider: React.FC<{
    children: React.ReactNode;
}> = ({ children }) => {
    return (
        <AppSettingsContext.Provider
            value={AppSettingsProvider.GetAllAppSettings()}
        >
            {children}
        </AppSettingsContext.Provider>
    );
};
