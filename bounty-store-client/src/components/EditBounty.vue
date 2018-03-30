<template>
    <div class="container">
        <h1 class="display-4 text-center">Edit Bounty</h1>
        <form @submit.prevent="onSubmit">
            <div class="form-group">
                <label for="bountyName">Name:</label>
                <input v-model="bounty.name" required class="form-control" type="text" name="bountyName" />
            </div>
            <div class="form-group">
                <label for="aliveReward">Alive Reward:</label>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">$</span>
                    </div>
                    <input v-model="bounty.aliveReward" required class="form-control" type="number" step="0.1" name="aliveReward" />
                </div>
            </div>
            <div class="form-group">
                <label for="deadReward">Dead Reward:</label>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">$</span>
                    </div>
                    <input v-model="bounty.deadReward" required class="form-control" type="number" step="0.1" name="deadReward" />
                </div>
            </div>
            <div class="form-group">
                <label for="bountyDescription">Description:</label>
                <textarea v-model="bounty.description" required class="form-control" name="bountyDescription"></textarea>
            </div>
            <div class="form-group">
                <label for="isCaptured">Is Closed?</label>
                <input v-model="bounty.captured" type="checkbox" />
            </div>
            <div class="form-group text-center">
                <button type="submit" class="btn btn-success">Update</button>
                <button type="button" class="btn btn-secondary" @click="cancel">Cancel</button>
            </div>
            <div class="text-center" v-show="success != null">
                <p class="text-success" v-show="success == true">Bounty Updated!</p>
                <p class="text-danger" v-show="success == false">Could not update bounty.</p>
            </div>
        </form>
    </div>
</template>

<script>
import axios from 'axios';
import {apiEndpoint} from '../config';

export default {
    data() {
        return {
            bounty: {},
            success: null
        };
    },
    created() {
        axios.get(apiEndpoint + '/' + this.$route.params.id)
            .then(res => this.bounty = res.data)
            .catch(() => this.success = false);
    },
    methods: {
        onSubmit() {
            axios.put(apiEndpoint + '/' + this.$route.params.id, this.bounty)
                .then(() => this.success = true)
                .catch(() => this.success = false);
        },
        cancel() {
            history.back();
        }
    }
};
</script>