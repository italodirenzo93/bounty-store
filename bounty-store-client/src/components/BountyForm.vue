<template>
    <form @submit.prevent="onSubmit">
        <div v-if="bounty.id" class="form-group">
            <label for="bountyId">ID:</label>
            <input v-model="bounty.id" class="form-control" :class="{ 'is-invalid': errors && errors.Id }" name="bountyId" readonly />
            <div v-if="errors" class="invalid-feedback">
                <p v-for="(err, index) in errors.Id" :key="index">{{err}}</p>
            </div>
        </div>
        <div class="form-group">
            <label for="bountyName">Name:</label>
            <input v-model="bounty.name" class="form-control" :class="{ 'is-invalid': errors && errors.Name }" type="text" name="bountyName" />
            <div v-if="errors" class="invalid-feedback">
                <p v-for="(err, index) in errors.Name" :key="index">{{err}}</p>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group col">
                <label for="aliveReward">Alive Reward:</label>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">$</span>
                    </div>
                    <input v-model="bounty.aliveReward" class="form-control" :class="{ 'is-invalid': errors && errors.AliveReward }" type="number" step="0.01" name="aliveReward" />
                    <div v-if="errors" class="invalid-feedback">
                        <p v-for="(err, index) in errors.AliveReward" :key="index">{{err}}</p>
                    </div>
                </div>
            </div>
            <div class="form-group col">
                <label for="deadReward">Dead Reward:</label>
                <div class="input-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text">$</span>
                    </div>
                    <input v-model="bounty.deadReward" class="form-control" :class="{ 'is-invalid': errors && errors.DeadReward }" type="number" step="0.01" name="deadReward" />
                    <div v-if="errors" class="invalid-feedback">
                        <p v-for="(err, index) in errors.DeadReward" :key="index">{{err}}</p>
                    </div>
                </div>
            </div>
        </div>
        <div class="form-group">
            <label for="bountyDescription">Description:</label>
            <textarea v-model="bounty.description" class="form-control" :class="{ 'is-invalid': errors && errors.Description }" name="bountyDescription"></textarea>
            <div v-if="errors" class="invalid-feedback">
                <p v-for="(err, index) in errors.Description" :key="index">{{err}}</p>
            </div>
        </div>
        <div class="form-group">
            <label for="isCaptured">Is Closed?</label>
            <input v-model="bounty.captured" type="checkbox" />
        </div>
        <div class="form-group text-center">
            <button v-if="newBounty" type="submit" class="btn btn-success">Create</button>
            <button v-else type="submit" class="btn btn-success">Update</button>
            <button type="button" class="btn btn-secondary" @click="onCancel">Cancel</button>
        </div>
    </form>
</template>

<script>
export default {
    props: {
        bounty: {
            type: Object,
            required: true
        },
        errors: Object
    },
    computed: {
        newBounty() {
            return !(this.bounty.id && this.bounty.id != 0);
        }
    },
    methods: {
        onSubmit() {
            this.$emit('submit', this.bounty);
        },
        onCancel() {
            this.$emit('cancel', this.bounty);
        }
    }
};
</script>