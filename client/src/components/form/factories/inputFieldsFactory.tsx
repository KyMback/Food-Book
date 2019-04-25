import { InputField } from "../fields/inputField";
import * as React from "react";

export interface InputFieldProps {
    type?: string;
    placeholder?: string;
    labelText: string;
    class?: string;
    row?: number;
    as?: string;
    onChange: (newValue: string) => void;
    value?: string;
}

export function makeInputFields(options: InputFieldProps[]): JSX.Element[] {
    return options.map(mapFunction);
}

function mapFunction(opt: InputFieldProps, key: number): JSX.Element {
    return (<InputField {...opt} key={key}/>);
}