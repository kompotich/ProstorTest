<template>
    <div class="persons">
        <div v-if="loading" class="loading">
            Загрузка...
        </div>

        <div class="person-add m-5">
            <div class="row">
                <div class="col-4">
                    <input id="firstNameInput" v-model="editModel.firstName" type="text" placeholder="Введите имя" class="form-control" />
                </div>
                <div class="col-4">
                    <input id="lastNameInput" v-model="editModel.lastName" type="text" placeholder="Введите фамилию" class="form-control" />
                </div>
                <div class="col-2">
                    <button type="button" class="btn btn-primary" @click="createOrUpdatePerson(editModel, getPersons)">Добавить</button>
                </div>
            </div>
        </div>

        <div v-if="persons" class="content m-5">
            <table class="table table-striped">
                <thead>
                    <tr>
                        <th>Имя</th>
                        <th>Фамилия</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="person in persons" :key="person.id">
                        <td>{{ person.firstName }}</td>
                        <td>{{ person.lastName }}</td>
                        <td>
                            <button type="button" class="btn btn-secondary" @click="createOrUpdatePerson(editModel, getPersons)">Редактировать</button>
                            <button type="button" class="btn btn-danger ml-2" @click="deletePerson(person.id, getPersons)">Удалить</button>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                persons: [],
                editModel: {
                    id: 0,
                    firstName: "",
                    lastName: "",
                    isUpdate: false
                }
            };
        },
        created() {
            this.getPersons();
        },
        methods: {
            getPersons() {
                this.persons = null;
                this.loading = true;

                fetch('person', { method: "get" })
                    .then(r => r.json())
                    .then(json => {
                        this.persons = json;
                        this.loading = false;
                        return;
                    });
            },
            deletePerson(personId, callback) {
                fetch(`person?personId=${personId}`, { method: "delete" })
                    .then(() => {
                        if (callback) {
                            callback();
                        }
                    });
            },
            createOrUpdatePerson(model, callback) {
                fetch('person', {
                    method: model.isUpdate ? "put" : "post",
                    headers: { "Content-Type": "application/json" },
                    body: JSON.stringify({
                        id: model.id,
                        firstName: model.firstName,
                        lastName: model.lastName
                    })
                }).then(() => {
                    if (callback) {
                        callback();
                    }
                });
            },
        },
    });
</script>