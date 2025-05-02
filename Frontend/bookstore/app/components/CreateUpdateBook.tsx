import Modal from "antd/es/modal/Modal";
import { BookRequest } from "../services/books";
import { Input } from "antd";
import { title } from "process";
import { useEffect, useState } from "react";
import TextArea from "antd/es/input/TextArea";

interface Props{
    mode: Mode;
    value: Book;
    isModalOpen: boolean;
    handleCancel: () => void;
    handleCreate: (request: BookRequest) => void;
    handleUpdate: (id: string, request: BookRequest) => void;
}

export enum Mode{
    Create,
    Edit,
}

export const CreateUpdateBook = ({
    mode,
    value,
    isModalOpen,
    handleCancel,
    handleCreate,
    handleUpdate,
}: Props) => {
    const[title, setTitle] = useState<string>("");
    const[description, setDescription] = useState<string>("");
    const[price, setPrice] = useState<number>(1);

    useEffect(() => {
        setTitle(value.title);
        setDescription(value.description);
        setPrice(value.price);
    }, [value]);

    const handleOnOk = async() => {
        const bookRequest = { title, description, price};

        mode == Mode.Create
            ? handleCreate(bookRequest) 
            : handleUpdate(value.id, bookRequest)
    }

    return (
        <Modal title={mode === Mode.Create ? "Добавить книгу" : "Редактировать книгу"} 
            open={isModalOpen} 
            onOk={handleOnOk}
            cancelText={"Отмена"}
            onCancel={handleCancel}
        >
            
            <div className="book_modal">
                <Input
                    value={title}
                    onChange={(e) => setTitle(e.target.value)}
                    placeholder="Название"
                />
                <TextArea 
                    value={description}
                    onChange={(e) => setDescription(e.target.value)}
                    autoSize={{ minRows: 3, maxRows: 3 }}
                    placeholder="Описание"
                />
                <Input 
                    value={price}
                    onChange={(e) => setPrice(Number(e.target.value))}
                    placeholder="Цена"
                />
            </div>
        </Modal>
    )
};